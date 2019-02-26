import { Params } from '@angular/router';

export interface BreadCrumb {
    url: string;
    label: string;
    params?: Params;
}
