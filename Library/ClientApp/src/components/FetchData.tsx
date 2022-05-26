import React, {ChangeEvent, Component} from "react";
import {BookViewModel} from "../model/BookViewModel";
import {Mapper} from "../mapper/Mapper";
import {Genre} from "../model/Genre";
import {Language} from "../language/Language";
import {BookModal} from "../modal/BookModal";


export interface Props {}

type State = {
  books:BookViewModel[];
  showModal:boolean;
  book: BookViewModel;
  ids: number[];
}

export class FetchData extends Component<Props, State> {
  static displayName = FetchData.name;

  constructor(props: any) {
    super(props);
    this.state = {
      books: [],
      showModal: false,
      book:{
        id: 0,
        name: "",
        createdDate: new Date(),
        genre: Genre.comedy,
        author: ""
      },
      ids:[]
    }
  }

  componentDidMount() {
    this.getBooksData();
  }

  async getBooksData() {
    const response = await fetch('getbooks');
    const data = await response.json();
    const books: BookViewModel[] = Mapper.toBookViewModels(data)
    this.setState({ books: books});
  }

  async getBookData(id: number) {
    const response = await fetch('getbook?id=' + id.toString());
    const data = await response.json();
    const book = Mapper.toBookViewModel(data)
    this.setState({ book: book});
    this.openModal();
  }

  async removeBook(id: number) {
    await fetch('removebook', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json;charset=utf-8'
      },
      body: JSON.stringify(id)
    });
    await this.getBooksData();
  }

  async removeBooks(ids: number[]) {
    if(ids.length == 0) return alert("Вы не выбрали что удалить")
    await fetch('removebooks', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json;charset=utf-8'
      },
      body: JSON.stringify(ids)
    });
    this.state.ids.length = 0;
    await this.getBooksData();
  }

  updateName(e:ChangeEvent<HTMLInputElement>) {
    const checked = e.target.checked;
    const id = Number(e.target.value);
    if(!this.state.ids.includes(id) && checked){
      this.state.ids.push(id);
    }
    if(this.state.ids.includes(id) && !checked){
      let index = this.state.ids.indexOf(id);
      this.state.ids.splice(index, 1)
    }
  }
  
  openModal = () =>{
    this.setState({  showModal: true});
  }  
  openAddModal = () =>{
    this.setState({  showModal: true, book:{id: 0, name: "", createdDate: new Date(), genre: Genre.comedy, author:""}});
  }

  closeModal = () =>{
    this.setState({  showModal: false});
  }

  render() {

    return (
        <div>
          <h1 id="tabelLabel">Книги</h1>
          <div><button onClick={()=>this.openAddModal()} className="btn btn-success" >Добавить</button> <button onClick={() => this.removeBooks(this.state.ids)} className="btn btn-danger">Удалить книги</button></div>
          <table className='table table-striped' aria-labelledby="tabelLabel">
            <thead>
            <tr>
              <th>ID</th>
              <th>Название</th>
              <th>Год</th>
              <th>Жанр</th>
              <th>Автор</th>
              <th></th>
              <th></th>
            </tr>
            </thead>
            <tbody>
            {this.state.books.map(book =>
                <tr key={book.id}>
                  <td>{book.id}</td>
                  <td onClick={() => this.getBookData(book.id)}>{book.name}</td>
                  <td>{book.createdDate.toString().slice(0,10)}</td>
                  <td>{Language.toGenre(book.genre)}</td>
                  <td>{book.author}</td>
                  <td><button onClick={() => this.removeBook(book.id)} className="btn btn-danger">Удалить</button></td>
                  <td><input onChange={(e) => this.updateName(e)} value={book.id} type="checkbox"/></td>
                </tr>
            )}
            </tbody>
          </table>
          <BookModal hide={() => this.closeModal()} isShown={this.state.showModal} book={this.state.book} getBooks={() => this.getBooksData()}/>
        </div>
    );
  }
}
