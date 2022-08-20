export class Data {
    id?: number;
    email: string;
    first_name: string;
    last_name: string;
    avatar: string;

    name: string;
    year: number;
    color: string;
    pantone_value: string;

    constructor() {
        this.email = '';
        this.first_name = '';
        this.last_name = '';
        this.avatar = '';

        this.name = '';
        this.year = 0;
        this.color = '';
        this.pantone_value = '';
      }
}