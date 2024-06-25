import { Injectable } from '@angular/core';
import {FormGroup} from "@angular/forms";


export interface ObjectKeyModel {
  [key: string]: any;
}

export interface PatchModel {
  path: string;
  value: any;
}

@Injectable({
  providedIn: 'root'
})
export class UserService {
  validateHTML(form: FormGroup, field: string, error: string, excludeErrors: string[] = []): boolean {
    const hasError = form.get(field)?.hasError(error);
    const excludedErrors = excludeErrors.some(excludeError => form.get(field)?.hasError(excludeError));

    return !!hasError && !excludedErrors;
  }
}
