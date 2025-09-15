import { ApplicationConfig, provideBrowserGlobalErrorListeners, provideZonelessChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { TokenInterceptor } from './core/interceptors/token.interceptor';
import { provideFirebaseApp, initializeApp } from '@angular/fire/app';
import { provideAuth, getAuth } from '@angular/fire/auth';


export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZonelessChangeDetection(),
    provideRouter(routes),
    provideHttpClient(
      withInterceptors([TokenInterceptor])
    ),
    provideFirebaseApp(() => initializeApp({
      apiKey: "AIzaSyBo3HXx7LTTvwiSmeFFWwwNeJ7-W8WNr2c",
      authDomain: "authenticator-b0b2e.firebaseapp.com",
      projectId: "authenticator-b0b2e",
      storageBucket: "authenticator-b0b2e.firebasestorage.app",
      messagingSenderId: "773474279220",
      appId: "1:773474279220:web:d66c214dc7fb79673dcf61"
    })),
    provideAuth(() => getAuth())
  ]
};
