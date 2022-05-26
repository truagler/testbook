import {BookViewModel} from "../model/BookViewModel";

export class Mapper{
	static toBookViewModel(data: any): BookViewModel{
		return new BookViewModel(data.id, data.name, data.createdDate, data.genre, data.author);
	}

	static toBookViewModels(data: any[]): BookViewModel[]{
		return data.map(book=> this.toBookViewModel(book));
	}
}