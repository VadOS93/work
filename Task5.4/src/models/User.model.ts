import { Data } from './Data.model';
import { Support } from './Support.model';

export class User {
  page: number;
  per_page: number;
  total: number
  total_pages: number;
  data: Data;
  support: Support;


  constructor() {
    this.data = new Data();
    this.support = new Support();
    this.page = 0;
    this.per_page = 0;
    this.total = 0;
    this.total_pages = 0;
  }
}