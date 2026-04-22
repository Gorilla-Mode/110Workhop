using WorkshopInputBetterCode.services;
using WorkshopInputBetterCode.ui;

var menuSelectService = new MenuSelectService(new TodoService());
var menuMainService = new MenuMainService(new TodoService(), menuSelectService);

bool run = true;
while (run)
{
    menuMainService.Run(ref run);
}