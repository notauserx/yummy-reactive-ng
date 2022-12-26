import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';


import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';


import { HeaderComponent } from './components/layout/header/header.component';
import { ContainerComponent } from './components/layout/container/container.component';
import { PrimeNgModule } from './primeng.module';
import { RecipeModule } from './recipe-module/recipe.module';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ContainerComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    PrimeNgModule,
    RecipeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
