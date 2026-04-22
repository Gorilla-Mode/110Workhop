using WorkshopInputBetterCode.interfaces;
using WorkshopInputBetterCode.services;
using WorkshopInputBetterCode.ui;

ITodoService       todoService       = new TodoService();
IMenuSelectService menuSelectService = new MenuSelectService(todoService);
IMenuMainService   menuMainService   = new MenuMainService(todoService, menuSelectService);

bool run = true;
while (run)
{
    menuMainService.Run(ref run);
}