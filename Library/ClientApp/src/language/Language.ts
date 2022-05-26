import {Genre} from "../model/Genre";

export class Language{
	static toGenre(genre: Genre){
		switch (genre){
			case Genre.detective: return "Детектив"
				break;
			case Genre.comedy: return "Комедия"
				break;
			case Genre.horror: return "Ужасы"
				break;
			case Genre.prose: return "Проза"
				break;
		}
	}
}