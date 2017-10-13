import { ProductBody } from './../../ProductDetails';

import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';



@Component({
    selector: 'productdetails',
    templateUrl: './productdetails.component.html'
})
export class ProductDetailsComponent {
    public products: ProductBody[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/ProductDetails').subscribe(result => {
            this.products = result.json() as ProductBody[];
        }, error => console.error(error));
    }
}