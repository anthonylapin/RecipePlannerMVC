# RecipePlanner
EGUI Laboratory exercise 2

- Simple Recipe Planner application using ASP.NET MVC, C# based on .NET 5
- Data should be stored in text files in selected folder (format explained at the end)
- Specify full path to your recipes.json file in config.json file.

### Main screen
- Displays list of all available recipes
- Has buttons to Add/Edit/Delete recipes

### Entry dialog
- user may Add new or Edit existing recipe
- recipe consist of multiline description and list of ingredients
  - each ingredient has name, quantity and unit where:
  - name is a multiword string (like bread flour)
  - quantity is a float number (like 1.0)
  - unit is a multiword string (any string is treated as a unit - so "red balbinka" is also a unit)
  
### Menu dialog
- user may create a list of recipes to be cooked
- program will compute sorted list of required ingredients to buy
- only compatible (=equal strings) units are summed up (see eggs with pcs) - if units are not compatible ingredients are presented separately (see salt)

### Data format
- recipes are stored in recipes.json
