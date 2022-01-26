using CadastroLivros.Classes;
using CadastroLivros.Enum;

string opcaoEscolhida;
BookRepository repository = new BookRepository();

static string opcaoUsuario()
{
    System.Console.WriteLine();
    System.Console.WriteLine("Cadastro de Livros - Menu");
    System.Console.WriteLine();
    System.Console.WriteLine("1 - Cadastrar novo Livro");
    System.Console.WriteLine("2 - Visualizar Livro");
    System.Console.WriteLine("3 - Listar Livros");
    System.Console.WriteLine("4 - Atualizar Livro");
    System.Console.WriteLine("5 - Excluir Livro");
    System.Console.WriteLine("X - Encerrar aplicação");
    System.Console.WriteLine();
    System.Console.Write("Infome a opção desejada: ");
    string opcao = Console.ReadLine().ToUpper();
    System.Console.WriteLine();
    return opcao;
}

do
{
    opcaoEscolhida = opcaoUsuario();

    switch (opcaoEscolhida)
    {
        case "1":
            System.Console.WriteLine("Gêneros de livros: ");
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }
            System.Console.Write("Digite o gênero entre as opções acima: ");       
            int inGenero = int.Parse(Console.ReadLine());        
            System.Console.Write("Digite o título do livro: ");
            string inTitulo = Console.ReadLine();
            System.Console.Write("Informe o autor(a) do livro: ");
            string inAutor = Console.ReadLine();
            System.Console.Write("Informe a descrição do livro: ");
            string inDescricao = Console.ReadLine();
            System.Console.Write("Digite o ano que o livro foi publicado: ");
            int inaAno = int.Parse(Console.ReadLine());
            Book newBook = new Book(
                ID: repository.nextID(),
                genre: (Genre)inGenero,
                inTitulo,
                inAutor,
                inDescricao,
                inaAno
            );
            repository.insert(newBook);
            System.Console.WriteLine("Livro cadastrado com sucesso!");
            break;
        case "2":
            if (!repository.isThereBook())
            {
                System.Console.WriteLine("Não há livros cadastrados no sistema!");
                break;
            }
            System.Console.Write("Informe o ID do livro: ");           
            int idBook = int.Parse(Console.ReadLine());
            System.Console.WriteLine();
            if (repository.validID(idBook) == -1)
            {
                System.Console.WriteLine("ID não cadastrado no sistema");
                break;
            }
            var bookView = repository.searchByID(idBook);
            System.Console.WriteLine(bookView);
            break;
        case "3":
            var bookList = repository.toList();
            if (!repository.isThereBook())
            {
                System.Console.WriteLine("Não há livros cadastrados no sistema!");
                break;
            }
            foreach (var book in bookList)
            {
                System.Console.WriteLine("#ID {0}: - {1}", book.getID(), book.getTitle());
            }
            break;
        case "4":
            if (!repository.isThereBook())
            {
                System.Console.WriteLine("Não há livros cadastrados no sistema!");
                break;
            }
            System.Console.Write("Digite o ID do livro a ser atualizado: ");
            int idB = int.Parse(Console.ReadLine());
            System.Console.WriteLine();
            if (repository.validID(idB) == -1)
            {
                System.Console.WriteLine("ID não cadastrado no sistema");
                break;
            }
            System.Console.WriteLine("Gêneros de livros: ");
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }
            System.Console.Write("Digite o gênero entre as opções acima: ");
            int genero = int.Parse(Console.ReadLine());
            System.Console.Write("Digite o título do livro: ");
            string titulo = Console.ReadLine();
            System.Console.Write("Informe o autor(a) do livro: ");
            string autor = Console.ReadLine();
            System.Console.Write("Informe a descrição do livro: ");
            string descricao = Console.ReadLine();
            System.Console.Write("Digite o ano que o livro foi publicado: ");
            int ano = int.Parse(Console.ReadLine());
            Book updateBook = new Book(
                ID: repository.nextID(),
                genre: (Genre)genero,
                titulo,
                autor,
                descricao,
                ano
            );
            repository.update(idB, updateBook);
            System.Console.WriteLine("Livro atualizado com sucesso!");
            break;
        case "5":
            if (!repository.isThereBook())
            {
                System.Console.WriteLine("Não há livros cadastrados no sistema!");
                break;
            }
            System.Console.Write("Informe o ID do livro a ser excluído: ");
            int id = int.Parse(Console.ReadLine());
            System.Console.WriteLine();
            if (repository.validID(id) == -1)
            {
                System.Console.WriteLine("ID não cadastrado no sistema");
                break;
            }
            repository.delete(id);
            System.Console.WriteLine("Livro excluído com sucesso!");
            break;
        case "X":
            System.Console.WriteLine("Aplicação encerrada!");
            break;
        default:
            System.Console.WriteLine("Opção inválida. Tente novamente!");
            break;
    }
} while (opcaoEscolhida != "X");
