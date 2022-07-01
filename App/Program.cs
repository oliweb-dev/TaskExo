using DAL.Entities;
using DAL.Services;


// Category
CategoryService categoryService = new CategoryService();

IEnumerable<Category> categories = categoryService.GetAll();
Console.WriteLine("Liste des categories :");
foreach (Category cat in categories)
{
    Console.WriteLine($"Id: {cat.Id} - Name: {cat.Name}");
}

Category category = categoryService.GetById(6);

//Category categoryToAdd = new Category()
//{
//    Id = 0,
//    Name = "Test"
//};

//int resultAdd = categoryService.AddCategory(categoryToAdd);

//int resultDelete = categoryService.DeleteById(7);

Console.ReadKey();