import { ModuleWithProviders } from "@angular/core";
import { Routes, RouterModule } from '@angular/router';

import HomeComponent from "./components/home/HomeComponent";
import AboutComponent from "./components/about/AboutComponent";
import NewsComponent from "./components/news/NewsComponent";
import ProjectsComponent from "./components/projects/ProjectsComponent";
import PaymentsComponent from "./components/payments/PaymentsComponent";
import HeaderComponent from "./components/shared/header/HeaderComponent";
import FooterComponent from "./components/shared/footer/FooterComponent";
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

// // Route config let's you map routes to components
// const routes: RouterConfig = [
//   // map '/persons' to the people list component
//   {
//     path: 'persons',
//     component: PeopleListComponent,
//   },
//   // map '/persons/:id' to person details component
//   {
//     path: 'persons/:id',
//     component: PersonDetailsComponent
//   },
//   // map '/' to '/persons' as our default route
//   {
//     path: '',
//     redirectTo: '/persons',
//     pathMatch: 'full'
//   },
// ];

// export const APP_ROUTER_PROVIDERS = [
//   provideRouter(routes)
// ];

export const ROUTER_MODULE: ModuleWithProviders = RouterModule.forRoot(routes);
