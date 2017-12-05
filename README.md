<h1>Invisible Library</h1>

<h2>WCF_Book</h2>
 <h3>Book CreateBook(string isbn, string code, string title, string author, string subject)</h3>
 <p>Cria uma instancia de <b>Book</b> com os parametros passados
 
 <h2>WCF_LibraryManager</h2>
 <p>Serviço de gerenciamento de livros.Para adicionar, buscar e atualizar os livros da biblioteca e gerenciar os alugueis de livro.
 
 <h3>void AddBook(string isbn, string code, string title, string author, string subject)</h3>
 <p>Adiciona um livro a lista de livros do Manager
 
 <h3>IList<Book>GetAllBooks()</h3>
 <p>Recupera todos os livros do Manager
 
 <h3>IList<Book> GetBooksBySubject(string subject)</h3>
 <p>Recupera os livros de um assunto
 
 <h3>IList<Book> GetBooksByAuthor(string author)</h3>
 <p>Recupar os livros de um autor
 
 <h3>Book GetBooksByCode(string code)</h3>
 <p>Recupera um livro contendo o codigo solicitado     

 <h3>void UpdateToBorrowed(Guid id,string client, DateTime dat)</h3>
 <p>Atualiza o livro para Emprestado
      
<h3>void UpdateToAvaible(Guid id, string client, DateTime date)</h3>
<p>Atualiza o livro para disponivel         

<h3>Loan GetLoan(Guid id)</h3>
<p>Recupera o emprestimo de um livro

<h3>IList<Loan> GetLoansFromClient(string client)</h3>
<p>Recupera todos os emprestimos de um client
      

<h2>WCF_LibraryDesk</h2>
<p>Se comunica com o WCF_LibraryManager para realizar os emprestimos e as devolucoes

<h2>bool BorrowBook(string code,string client,DateTime date)</h2>
<p>Aluga o livro selecionado no nome do cliente selecionado

<h2>bool ReturnBook(string code, string client, DateTime date)</h2>
<p>Retorna um livro selecionado

<h2>void Authenticate(string client)</h2>
<p>Autentica o cliente no sistema
         
