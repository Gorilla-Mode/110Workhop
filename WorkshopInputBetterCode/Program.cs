using WorkshopInputBetterCode.services;

var menuSelectService = new MenuSelectService(new TodoService());
var menuMainService = new MenuMainService(new TodoService(), menuSelectService);

while (true)
{
    menuMainService.Run();
}