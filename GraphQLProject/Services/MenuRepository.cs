using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Services
{
    public class MenuRepository : IMenuRepository
    {
        private readonly GraphQLDbContext _dbContext;

        public MenuRepository(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Menu> GetAllMenu()
        {
            return _dbContext.Menus.ToList();
        }

        public Menu GetMenuById(int id)
        {
            return _dbContext.Menus.Find(id);
        }

        public Menu AddMenu(Menu menu)
        {
            _dbContext.Menus.Add(menu);
            _dbContext.SaveChanges();
            return menu;
        }

        public Menu UpdateMenu(int id, Menu menu)
        {
            var menuResult = _dbContext.Menus.Find(id);

            menuResult.Name = menu.Name;
            menuResult.Description = menu.Description;
            menuResult.Price = menu.Price;

            _dbContext.SaveChanges();
            return menu;
        }

        public void DeleteMenu(int id)
        {
            var menuResult = _dbContext.Menus.Find(id);

            _dbContext.Menus.Remove(menuResult);
            _dbContext.SaveChanges();
        }
    }
}
