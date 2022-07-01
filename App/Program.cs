using DAL.Entities;
using DAL.Services;
using E = DAL.Entities;


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

Console.WriteLine("-------------------------------------------------");

// Tâches
// ***************************************************************************
TaskService taskService = new TaskService();

// Ajouter
//E.Task taskToAdd = new E.Task()
//{
//    Id = 0,
//    Name = "Test",
//    Description = "Ma description",
//    DateCreate = new DateTime(2022, 7, 5, 20, 15, 0),
//    DateExpectedEnd = new DateTime(2022, 7, 5, 21, 0, 0),
//    DateEnd = null,
//    CategoryId = 2,
//    PersonId = 1,
//};

//int resultAddTask = taskService.AddTask(taskToAdd);

//int resultDelete = taskService.DeleteById(9);

E.Task taskToUpdate = taskService.GetById(7);

taskToUpdate.DateEnd = new DateTime(2022, 7, 2, 13, 0, 0);

int resultTaskUpdate = taskService.Update(taskToUpdate);

IEnumerable<E.Task> tasks = taskService.GetAll();
Console.WriteLine("\nListe des tâches :");
Console.WriteLine("------------------");
foreach (E.Task task in tasks)
{
    Console.WriteLine($"\nId: {task.Id}");
    Console.WriteLine($"Titre: {task.Name}");
    Console.WriteLine($"Description: {task.Description}");
    Console.WriteLine($"Début de la tâche: {task.DateCreate.ToString("MM/dd/yyyy H:mm")}");
    Console.WriteLine($"Fin de la tâche prévue: {task.DateExpectedEnd.ToString("MM/dd/yyyy H:mm")}");
    string txtDateEnd = task.DateEnd?.ToString("MM/dd/yyyy H:mm") ?? "-";
    Console.WriteLine($"Fin de la tâche effective: {txtDateEnd}");
    Console.WriteLine($"Catégorie: {categoryService.GetById(task.CategoryId).Name}");
    Console.WriteLine($"Responsable: {personService.GetById(task.PersonId).FirstName} {personService.GetById(task.PersonId).LastName}");
}

E.Task taskGetById = taskService.GetById(2);

IEnumerable<E.Task> tasksByCategory = taskService.GetByCategoryId(2);
Console.WriteLine("\nListe des tâches pour une catégorie :");
Console.WriteLine("-------------------------------------");
foreach (E.Task task in tasksByCategory)
{
    Console.WriteLine($"\nId: {task.Id}");
    Console.WriteLine($"Titre: {task.Name}");
    Console.WriteLine($"Description: {task.Description}");
    Console.WriteLine($"Début de la tâche: {task.DateCreate.ToString("MM/dd/yyyy H:mm")}");
    Console.WriteLine($"Fin de la tâche prévue: {task.DateExpectedEnd.ToString("MM/dd/yyyy H:mm")}");
    string txtDateEnd = task.DateEnd?.ToString("MM/dd/yyyy H:mm") ?? "-";
    Console.WriteLine($"Fin de la tâche effective: {txtDateEnd}");
    Console.WriteLine($"Catégorie: {categoryService.GetById(task.CategoryId).Name}");
    Console.WriteLine($"Responsable: {personService.GetById(task.PersonId).FirstName} {personService.GetById(task.PersonId).LastName}");
}

IEnumerable<E.Task> tasksByPerson = taskService.GetByPersonId(1);
Console.WriteLine("\nListe des tâches pour une personne :");
Console.WriteLine("-------------------------------------");
foreach (E.Task task in tasksByPerson)
{
    Console.WriteLine($"\nId: {task.Id}");
    Console.WriteLine($"Titre: {task.Name}");
    Console.WriteLine($"Description: {task.Description}");
    Console.WriteLine($"Début de la tâche: {task.DateCreate.ToString("MM/dd/yyyy H:mm")}");
    Console.WriteLine($"Fin de la tâche prévue: {task.DateExpectedEnd.ToString("MM/dd/yyyy H:mm")}");
    string txtDateEnd = task.DateEnd?.ToString("MM/dd/yyyy H:mm") ?? "-";
    Console.WriteLine($"Fin de la tâche effective: {txtDateEnd}");
    Console.WriteLine($"Catégorie: {categoryService.GetById(task.CategoryId).Name}");
    Console.WriteLine($"Responsable: {personService.GetById(task.PersonId).FirstName} {personService.GetById(task.PersonId).LastName}");
}

IEnumerable<E.Task> tasksUnfinishedTask = taskService.GetUnfinishedTask();
Console.WriteLine("\nListe des tâches inachevées :");
Console.WriteLine("-------------------------------------");
foreach (E.Task task in tasksByPerson)
{
    Console.WriteLine($"\nId: {task.Id}");
    Console.WriteLine($"Titre: {task.Name}");
    Console.WriteLine($"Description: {task.Description}");
    Console.WriteLine($"Début de la tâche: {task.DateCreate.ToString("MM/dd/yyyy H:mm")}");
    Console.WriteLine($"Fin de la tâche prévue: {task.DateExpectedEnd.ToString("MM/dd/yyyy H:mm")}");
    string txtDateEnd = task.DateEnd?.ToString("MM/dd/yyyy H:mm") ?? "-";
    Console.WriteLine($"Fin de la tâche effective: {txtDateEnd}");
    Console.WriteLine($"Catégorie: {categoryService.GetById(task.CategoryId).Name}");
    Console.WriteLine($"Responsable: {personService.GetById(task.PersonId).FirstName} {personService.GetById(task.PersonId).LastName}");
}


Console.ReadKey();