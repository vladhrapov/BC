import { ModuleWithProviders } from "@angular/core";
import { Routes, RouterModule } from '@angular/router';

// Components
import HomeComponent from "./components/home/HomeComponent";
import AboutComponent from "./components/about/AboutComponent";
import NewsComponent from "./components/news/NewsComponent";
import ProjectsComponent from "./components/projects/ProjectsComponent";
import PaymentsComponent from "./components/payments/PaymentsComponent";
import SignInComponent from "./components/authorization/signIn/SignInComponent";
import SignUpComponent from "./components/authorization/signUp/SignUpComponent";
import ProfileComponent from "./components/authorization/profile/ProfileComponent";
import ProfileGuardService from "./components/authorization/profile/ProfileGuardService";

const routes: Routes = [
  { path: "", component: HomeComponent},
  { path: "about", component: AboutComponent },
  { path: "news", component: NewsComponent },
  { path: "projects", component: ProjectsComponent },
  { path: "payments", component: PaymentsComponent },
  { path: "sign-in", component: SignInComponent },
  { path: "sign-up", component: SignUpComponent },
  { path: "profile", component: ProfileComponent, canActivate: [ProfileGuardService] },
  //{ path: '**', component: PageNotFoundComponent }
]

export const ROUTER_MODULE: ModuleWithProviders = RouterModule.forRoot(routes);
