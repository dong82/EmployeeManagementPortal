
use employees ;


DROP PROCEDURE IF EXISTS employees.sp_insert_dept_emp;

DELIMITER $$

CREATE PROCEDURE employees.sp_insert_dept_emp(
	in empNo int, 
	in deptNo char(4)
)
BEGIN
-- 	10001	d005
	
	SELECT
		@dept_no := dept_no, 
		@from_Date := from_date, 
		@to_Date := to_date 
	FROM vw_dept_emp_current vdec
	WHERE
		vdec.emp_no = empNo;


	IF deptNo <> @dept_no 
	THEN
		UPDATE dept_emp de
		SET
			de.to_Date = CURDATE() 
		WHERE
			de.emp_no = empNo
			AND de.dept_no  = @dept_No
			AND de.from_date = @from_Date
			AND de.to_date = @to_Date;

		INSERT INTO dept_emp (
			emp_no, 
			dept_no, 
			from_date, 
			to_date
		)
		VALUES(
			empNo, 
			deptNo, 
			CURDATE(), 
			'9999-01-01'
		);
	
		UPDATE dept_emp_current de
		SET
			de.dept_no = deptNo,
			de.from_date = CURDATE(),
			de.to_date = '9999-01-01'
		WHERE
			de.emp_no = empNo;

	END IF;
	
END $$

DELIMITER ;


