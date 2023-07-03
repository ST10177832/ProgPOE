using System;
using System.Collections.Generic;
using System.Linq;

class Ingredient
{
    public string Name { get; set; }
    public int Calories { get; set; }
    public string FoodGroup { get; set; }
}
class Recipe
{
    private List<Ingredient> ingredients;
    private string[] steps;

    public Recipe()
    {
        ingredients = new List<Ingredient>();
    }

    public void EnterRecipe()
    {
        Console.WriteLine("Enter the number of ingredients:");
        int numIngredients = int.Parse(Console.ReadLine());

        for (int i = 0; i < numIngredients; i++)
        {
            Console.WriteLine($"Enter the name of ingredient {i + 1}:");
            string name = Console.ReadLine();

            Console.WriteLine($"Enter the quantity of ingredient {i + 1}:");
            string quantity = Console.ReadLine();

            Console.WriteLine($"Enter the unit of measurement for ingredient {i + 1}:");
            string unit = Console.ReadLine();
            Console.WriteLine($"Enter the number of calories for ingredient {i + 1}:");
            int calories = int.Parse(Console.ReadLine());

            Console.WriteLine($"Enter the food group for ingredient {i + 1}:");
            string foodGroup = Console.ReadLine();

            Ingredient ingredient = new Ingredient
            {
                Name = name,
                Calories = calories,
                FoodGroup = foodGroup
            };

            ingredients.Add(ingredient);
        }

        Console.WriteLine("Enter the number of steps:");
        int numSteps = int.Parse(Console.ReadLine());
        steps = new string[numSteps];
  for (int i = 0; i < numSteps; i++)
        {
            Console.WriteLine($"Enter step {i + 1}:");
            steps[i] = Console.ReadLine();
        }
    }

    public void DisplayRecipe()
    {
        Console.WriteLine("\nRecipe:");

        Console.WriteLine("\nIngredients:");
        foreach (Ingredient ingredient in ingredients)
        {
            Console.WriteLine($"{ingredient.Name} - {ingredient.Calories} calories - {ingredient.FoodGroup}");
        }
        Console.WriteLine("\nSteps:");
        for (int i = 0; i < steps.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {steps[i]}");
        }
    }

    public int CalculateTotalCalories()
    {
        int totalCalories = 0;
        foreach (Ingredient ingredient in ingredients)
        {
            totalCalories += ingredient.Calories;
        }
        return totalCalories;
    }

    public void ScaleRecipe(double scaleFactor)
    {
        foreach (Ingredient ingredient in ingredients)
        {
            ingredient.Calories = (int)(ingredient.Calories * scaleFactor);
        }
    }
    public void ResetQuantities()
    {
        // Revert ingredient quantities to their original values
        // (assuming original values are stored elsewhere)
    }

    public void ClearRecipe()
    {
        ingredients.Clear();
        steps = null;
    }

    public List<Recipe> FilterRecipesByIngredient(string ingredientName)
    {
        return ingredients.Any(ingredient => ingredient.Name.Equals(ingredientName, StringComparison.OrdinalIgnoreCase))
            ? new List<Recipe> { this }
            : new List<Recipe>();
    }

    public List<Recipe> FilterRecipesByFoodGroup(string foodGroup)
    {
        return ingredients.Any(ingredient => ingredient.FoodGroup.Equals(foodGroup, StringComparison.OrdinalIgnoreCase))
            ? new List<Recipe> { this }
            : new List<Recipe>();
    }
    public List<Recipe> FilterRecipesByFoodGroup(string foodGroup)
    {
        return ingredients.Any(ingredient => ingredient.FoodGroup.Equals(foodGroup, StringComparison.OrdinalIgnoreCase))
            ? new List<Recipe> { this }
            : new List<Recipe>();
    }

    public List<Recipe> FilterRecipesByCalories(int maxCalories)
    {
        return CalculateTotalCalories() <= maxCalories
            ? new List<Recipe> { this }
            : new List<Recipe>();
    }
}
class Program
{
    static List<Recipe> recipes = new List<Recipe>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Enter a new recipe");
            Console.WriteLine("2. Display the recipe");
            Console.WriteLine("3. Calculate total calories");
            Console.WriteLine("4. Scale the recipe");
            Console.WriteLine("5. Reset quantities");
            Console.WriteLine("6. Clear the recipe");
            Console.WriteLine("7. Filter the recipes");
            Console.WriteLine("8. Exit");

            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Recipe recipe = new Recipe();
                    recipe.EnterRecipe();
                    recipes.Add(recipe);
                    break;
                case 2:
                    DisplayRecipes();
                    break;
                case 3:
                    Console.WriteLine("Enter the recipe number:");
                    int recipeNumber = int.Parse(Console.ReadLine());
                    if (recipeNumber >= 1 && recipeNumber <= recipes.Count)
                    {
                        Recipe selectedRecipe = recipes[recipeNumber - 1];
                        int totalCalories = selectedRecipe.CalculateTotalCalories();
                        Console.WriteLine("Total Calories: " + totalCalories);
                    }
                    else
                    {
                        Console.WriteLine("Invalid recipe number. Please try again.");
                    }
                    break;
                case 4:
                    Console.WriteLine("Enter the recipe number:");
                    int recipeNum = int.Parse(Console.ReadLine());
                    if (recipeNum >= 1 && recipeNum <= recipes.Count)
                    {
                        Recipe selectedRecipe = recipes[recipeNum - 1];
                        Console.WriteLine("Enter the scale factor (0.5, 2, or 3):");
                        double scaleFactor = double.Parse(Console.ReadLine());
                        selectedRecipe.ScaleRecipe(scaleFactor);
                        Console.WriteLine("Recipe scaled successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid recipe number. Please try again.");
                    }
                    break;
                case 5:
                    Console.WriteLine("Enter the recipe number:");
                    int num = int.Parse(Console.ReadLine());
                    if (num >= 1 && num <= recipes.Count)
                    {
                        Recipe selectedRecipe = recipes[num - 1];
                        selectedRecipe.ResetQuantities();
                        Console.WriteLine("Quantities reset successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid recipe number. Please try again.");
                    }
                    break;
                case 6:
                    Console.WriteLine("Enter the recipe number:");
                    int recipeNumToDelete = int.Parse(Console.ReadLine());
                    if (recipeNumToDelete >= 1 && recipeNumToDelete <= recipes.Count)
                    {
                        Recipe selectedRecipe = recipes[recipeNumToDelete - 1];
                        recipes.Remove(selectedRecipe);
                        Console.WriteLine("Recipe deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid recipe number. Please try again.");
                    }
                    break;
                case 7:
                    FilterRecipes();
                    break;
                case 8:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
    static void DisplayRecipes()
    {
        if (recipes.Count > 0)
        {
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"\nRecipe {i + 1}:");
                recipes[i].DisplayRecipe();
            }
        }
        else
        {
            Console.WriteLine("No recipes found.");
        }
    }

    static void FilterRecipes()
    {
        Console.WriteLine("\nSelect a filtering option:");
        Console.WriteLine("a. Filter by ingredient");
        Console.WriteLine("b. Filter by food group");
        Console.WriteLine("c. Filter by maximum calories");

        char filterOption = char.ToLower(Console.ReadKey().KeyChar);

        switch (filterOption)
        {
            case 'a':
                Console.WriteLine("\nEnter the name of the ingredient:");
                string ingredientName = Console.ReadLine();

                List<Recipe> filteredByIngredient = recipes
                    .SelectMany(recipe => recipe.FilterRecipesByIngredient(ingredientName))
                    .ToList();

                DisplayFilteredRecipes(filteredByIngredient);
                break;
            case 'b':
                Console.WriteLine("\nEnter the food group:");
                string foodGroup = Console.ReadLine();
                List<Recipe> filteredByFoodGroup = recipes
                           .SelectMany(recipe => recipe.FilterRecipesByFoodGroup( foodGroup))
                           .ToList();

                DisplayFilteredRecipes(filteredByFoodGroup);
                break;
            case 'c':
                Console.WriteLine("\nEnter the maximum calories:");
                int maxCalories = int.Parse(Console.ReadLine());

                List<Recipe> filteredByCalories = recipes
                    .SelectMany(recipe => recipe.FilterRecipesByCalories(maxCalories))
                    .ToList();

                DisplayFilteredRecipes(filteredByCalories);
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
    static void DisplayFilteredRecipes(List<Recipe> filteredRecipes)
    {
        if (filteredRecipes.Count > 0)
        {
            for (int i = 0; i < filteredRecipes.Count; i++)
            {
                Console.WriteLine($"\nFiltered Recipe {i + 1}:");
                filteredRecipes[i].DisplayRecipe();
            }
        }
        else
        {
            Console.WriteLine("No recipes found matching the filter criteria.");
        }
    }
}




