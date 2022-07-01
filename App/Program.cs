using DAL.Entities;
using DAL.Services;


// Category
// ***************************************************************************
CategoryService categoryService = new CategoryService();

IEnumerable<Category> categories = categoryService.GetAll();
Console.WriteLine("Liste des categories :");
foreach (Category cat in categories)
{
    Console.WriteLine($"Id: {cat.Id} - Name: {cat.Name}");
}

Category categoryGetById = categoryService.GetById(6);

//Category categoryToAdd = new Category()
//{
//    Id = 0,
//    Name = "Test"
//};

//int resultAdd = categoryService.AddCategory(categoryToAdd);

//int resultDelete = categoryService.DeleteById(7);

Console.WriteLine("-------------------------------------------------");

// Person
// ***************************************************************************
PersonService personService = new PersonService();

IEnumerable<Person> people = personService.GetAll();
Console.WriteLine("Liste des utilisateurs :");
foreach (Person person in people)
{
    Console.WriteLine($"Id: {person.Id} - LastName: {person.LastName} - FirstName: {person.FirstName}");
}

Person personGetById = personService.GetById(1);

//Person personToAdd = new Person()
//{
//    Id = 0,
//    LastName = "Wayne",
//    FirstName = "Bruce"
//};

//int resultPersonAdd = personService.AddPerson(personToAdd);

//Person personToUpdate = personService.GetById(6);
//personToUpdate.LastName = "Bravo !";
//personToUpdate.FirstName = "Test réussi";
//int resultPersonUpdate = personService.Update(personToUpdate);


Console.ReadKey();