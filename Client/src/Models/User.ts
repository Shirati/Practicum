// import * as internal from "stream";

import Child from "./Child";

export default class User {
    constructor(
        public NumUser: number = 0,
        public IdUser: String="",
        public FirstName: string="",
        public LastName: string="",
        public Date: Date =null,
        public MaleOrFemale: string="",
        public Hmo: string="מכבי",
        public Children: Child[],

    ) { }
}