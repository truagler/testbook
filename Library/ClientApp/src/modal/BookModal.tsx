import React, {ChangeEvent, Component} from "react";
import {Modal, ModalBody, ModalFooter, ModalHeader} from "reactstrap";
import {BookViewModel} from "../model/BookViewModel";
import {BookBlank} from "../model/BookBlank";
import {Genre} from "../model/Genre";
import {Language} from "../language/Language";

export interface Props{
	isShown: boolean;
	hide: () => void;
	book: BookViewModel;
	getBooks: () => void;
}

type State = {
	name: string;
	createdDate: Date;
	genre: Genre.comedy;
	author: string;
}

export class BookModal extends Component<Props, State>{

	constructor(props:any) {
		super(props);
		
		this.state = {
				name: "",
				createdDate: new Date(),
				genre: Genre.comedy,
				author: ""
		}
	}

	updateName(e:ChangeEvent<HTMLInputElement>) {
		const name = e.target.value;
		this.setState({name: name});
	}

	updateGenre(e:ChangeEvent<HTMLSelectElement>) {
		const genre = Number(e.target.value);
		this.setState({genre: genre});
	}

	updateAuthor(e:ChangeEvent<HTMLInputElement>) {
		const author = e.target.value;
		this.setState({author: author});
	}

	updateDate(e:ChangeEvent<HTMLDataElement>) {
		const value = e.target.value;
		const date =new Date(Date.parse(value));
		this.setState({createdDate: date})
	}
	
	async updateBook() {
		if(this.state.name == "" || this.state.author) return alert("Вы не заполнили все поля")
		const blank = new BookBlank(this.props.book.id, this.state.name, this.state.createdDate, this.state.genre, this.state.author)
		await fetch('updatebook', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json;charset=utf-8'
			},
			body: JSON.stringify(blank)
		});
		this.props.hide();
		this.props.getBooks();
	}

	async addBook() {
		const blank = new BookBlank(0, this.state.name, this.state.createdDate, this.state.genre, this.state.author)
		await fetch('addbook', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json;charset=utf-8'
			},
			body: JSON.stringify(blank)
		});
		this.props.hide();
		this.props.getBooks();
	}
	
	render() {
		var valueArray = Object.values(Genre);
		
		return (
			<div>
				<Modal size="lg"
					   aria-labelledby="contained-modal-title-vcenter"
					   isOpen={this.props.isShown}
					   fade={false}
				>
					<ModalHeader>
						<h1>{this.props.book.id != 0 ? "Форма редактирования книги: "+ this.props.book.name : "Форма добавления книги"}</h1>
					</ModalHeader>
					<ModalBody>
						<div>
							<b>Наименование: </b><input onChange={(e) => this.updateName(e)} type="text" defaultValue={this.props.book.name}/>
						</div>
						<div>
							<b>Дата: </b><input onChange={(e) => this.updateDate(e)} type="date"/>
						</div>
						<div>
							<b>Жанр: </b>
							<select defaultValue={this.props.book.genre} onChange={(e) => this.updateGenre(e)}>
								{valueArray.map((key, value) => <option value={value} key={key}>{Language.toGenre(value)}</option>)}
							</select>
						</div>
						<div>
							<b>Автор: </b><input  onChange={(e) => this.updateAuthor(e)}  type="text" defaultValue={this.props.book.author}/>
						</div>
					</ModalBody>
					<ModalFooter>
						<button onClick={this.props.book.id != 0 ? ()=> this.updateBook() : () => this.addBook()} className="btn btn-success">{this.props.book.id != 0 ? "Изменить" : "Добавить"}</button>
						<button onClick={()=>this.props.hide()} className="btn btn-danger">Закрыть</button>
					</ModalFooter>
				</Modal>
			</div>
		);
	}
}