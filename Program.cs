// Create books
var book1 = new Book {
    title = "The Catcher in the Rye",
    author = "J.D. Salinger"
};

var book2 = new Book {
    title = "The Seven Husbands of Evelyn Hugo",
    author = "Taylor Jenkins Reid"
};

var book3 = new Book {
    title = "The Name of the Wind",
    author = "Patrick Rothfuss"
};

var book4 = new Book {
    title = "Never Let Me Go",
    author = "Kazuo Ishiguro"
};

// Lists recommended books
var recommendedBooks = new List<Book> {
    book2, book3, book4
};

// Create members
var member1 = new Member {
    firstName = "John",
    lastName = "Doe",
    favouriteBook = book1.title,
    readingList = new List<Book> { book3 }
};

var member2 = new Member {
    firstName = "Lily",
    lastName = "Potts",
    favouriteBook = book2.title,
    readingList = new List<Book> { book4 }
};

var member3 = new Member {
    firstName = "Darla",
    lastName = "Mitchell",
    favouriteBook = book3.title,
    readingList = new List<Book> { book4, book2 }
};

// List of members
var memberList = new List<Member> {
    member1, member2, member3
};

while (true) {
    GiveInstructions();
    var userInput = Console.ReadLine();
    if (userInput == "X") {
        break;
    }
    switch (userInput) {
        case "Books": {
            Console.WriteLine("The Book Club recommends:");
            foreach (var book in recommendedBooks) {
                book.GiveDetails();
            }
            break;
        }
        case "Members": {
            Console.WriteLine("The members of the Book Club are:");
            foreach (var member in memberList) {
                member.MemberDetails();
            }
            break;
        }
        case "TBR": {
            Console.WriteLine("The members reading lists are as follows:");
            foreach (var mem in memberList) {
                mem.ReadingList();
            }
            break;
        }
        case "New Member": {
            Console.WriteLine("Please enter the first name:");
            var first = Console.ReadLine();
            Console.WriteLine("Please enter the last name:");
            var last = Console.ReadLine();
            
            var newMember = new Member {
                firstName = first,
                lastName = last,
                favouriteBook = "",
                readingList = new List<Book> { new Book() }
            };
            memberList.Add(newMember);

            Console.WriteLine($"{newMember.firstName} {newMember.lastName} added successfully");
            break;
        }
        case "New Book": {
            Console.WriteLine("Please enter the title:");
            var newTitle = Console.ReadLine();
            Console.WriteLine("Please enter the author:");
            var newAuthor = Console.ReadLine();
            
            var newBook = new Book {
                title = newTitle,
                author = newAuthor
            };
            recommendedBooks.Add(newBook);

            Console.WriteLine($"{newBook.title} by {newBook.author} added successfully");
            break;
        }
        default: {
            Console.WriteLine("I did not understand your request");
            break;
        }
    }
    Console.WriteLine("\nPress any key to continue");
    Console.ReadKey();
}

static void GiveInstructions() {
    Console.WriteLine("\nWelcome to the Book Club! \nPlease select an option or type 'X' to exit:");
    Console.WriteLine("Books = See a list of recommended books \nMembers = See a list of members\nTBR = See the members reading lists\nNew Member = Add a new member\nNew Book = Add a book to the reading list\n");
}

public class Book {
    public string title;
    public string author;

    public void GiveDetails() {
        Console.WriteLine($"{title} by {author}.");
    }
}

public class Member {
    public string firstName;
    public string lastName;
    public string favouriteBook;
    public List<Book> readingList;

    public void MemberDetails() {
        Console.WriteLine($"{firstName} {lastName}");
    }

    public void ReadingList() {
        Console.WriteLine($"{firstName} wants to read:");
        foreach (var book in readingList) {
            Console.WriteLine($"{book.title} by {book.author}");
        }
    }
}
