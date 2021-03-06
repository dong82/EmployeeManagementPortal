import { AuthService } from 'src/app/user/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  isLoggedIn: boolean;
  // userName: string;
  // userRoles: string;

  get userName() {
    return this.authService.userName;
  }
  get userRole() {
    return this.authService.userRole;
  }

  constructor(
    private authService: AuthService) {
    this.isLoggedIn = false;
  }

  setLoggedIn(loggedIn: boolean|null) {
    this.isLoggedIn = loggedIn;

    // console.log(`loggedIn: ${loggedIn}`);
    // console.log(`!loggedIn: ${!loggedIn}`);
    // console.log(`!sessionStorage['authPreChecked']: ${!sessionStorage['authPreChecked']}`);
    // console.log(`sessionStorage['forceLogin_EMP.Web']: ${sessionStorage['forceLogin_EMP.Web']}`);
    // console.log(`sessionStorage['forceLogout_EMP.Web']: ${sessionStorage['forceLogout_EMP.Web']}`);
    // console.log(`sessionStorage['originalUrl']: ${sessionStorage['originalUrl']}`);
    if (loggedIn) {
      if (sessionStorage['forceLogout_EMP.Web']) {
        this.logOutThisTabOnly();
      }
    } else if (!loggedIn) {
      if (sessionStorage['forceLogin_EMP.Web']) {
        sessionStorage.removeItem('forceLogin_EMP.Web');
        sessionStorage['authPreChecked'] = true;
        this.authService.preCheckAuthSession(window.location.href);
      } else if (!sessionStorage['authPreChecked']) {
        sessionStorage['authPreChecked'] = true;
        this.authService.preCheckAuthSession(window.location.href);
      }
    }
  }

  ngOnInit() {
    this.refreshCookie();

    window.addEventListener('storage', (event) => {
      if (event.key === 'forceLogout_EMP.Web_Shared' && !!event.newValue) {
        sessionStorage['forceLogout_EMP.Web'] = true;
      } else if (event.key === 'forceLogin_EMP.Web_Shared' && !!event.newValue) {
        sessionStorage['forceLogin_EMP.Web'] = true;
      }
    });

    this.authService.loginChanged.subscribe(loggedIn => {
      console.log(`loggedIn set by obs: ${loggedIn}`);
      this.setLoggedIn(loggedIn);
    });

    if (!this.isLoggedIn) {
      this.authService.isLoggedIn().then(loggedIn => {
        console.log(`loggedIn set by promise: ${loggedIn}`);
        this.setLoggedIn(loggedIn);
      });
    }
  }

  refreshCookie() {
    this.authService.getUser().then(data => {
      console.log('Cookie refreshed');
      console.log(JSON.stringify(data));
    });
  }

  login(): void {
    localStorage['forceLogin_EMP.Web_Shared'] = true;
    sessionStorage['originalUrl'] = window.location.href;
    this.authService.login();
    localStorage.removeItem('forceLogin_EMP.Web_Shared');
  }

  logOut(): void {
    // Use localStorage to support multi-tab sign out
    localStorage['forceLogout_EMP.Web_Shared'] = true;
    this.logOutThisTabOnly();
    localStorage.removeItem('forceLogout_EMP.Web_Shared');
  }

  logOutThisTabOnly(): void {
    console.log('logOutThisTabOnly');
    this.authService.logout();
    // sessionStorage.removeItem('authPreChecked');
    sessionStorage.removeItem('forceLogout_EMP.Web');
  }
}
