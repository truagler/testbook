import {Genre} from "./Genre";

export class BookViewModel{
	public id: number;
	public name: string;
	public createdDate: Date;
	public genre: Genre;
	public author: string;

	constructor(id: number, name: string, createdDate: Date, genre: Genre, author: string,) {
		this.id = id;
		this.name = name;
		this.createdDate = createdDate;
		this.genre = genre;
		this.author = author;
	}
}