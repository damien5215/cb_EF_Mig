# dotnet-ef-migrations

----------------------------------------------------------------

NOTES (Treehouse)

----------------------------------------------------------------

The Entity Framework NuGet package includes a set of commands related to Code First Migrations that can be used to enable migrations, add a migration, and update your database.

Code First Migrations allows you to update an existing database when your model changes without losing any data.

Without Code First Migrations, you have to manually manage keeping your application's data model in sync with your database when changes are made.

A migration is represented by a C# class that is added to your project.

Because each migration is represented by its own class, your project will naturally include a history of your model changes.

The Enable-Migrations command won't work if your project doesn't contain a class that inherits from the EF DbContext base class.

Setting the database initializer to null disables database initialization within EF. Without this, if we ran our application, EF would create our database.

----------------------------------------------------------------

If you see an error in a migration class it typically means that you have an issue in your entity data model that needs to be resolved. TRUE.

Being able to generate clean migration classes ensures that your requirements for your application's data are correctly implemented in both the entity data model and the database.

To add a migration, type the "Add-Migration" command into the Package Manager Console followed by the name you want to use for the migration.

When executing the command, EF will add a file to the "Migrations" folder using the provided migration name for the filename, prefixed with a timestamp value.

Prefixing a migration's filename with a timestamp ensures that migration files display in chronological order. TURE.

Displaying the migration files in chronological order makes it easy to identify the order that they were created in.

The DbSet class contains a method named "AddOrUpdate" that can be used to only insert data if it doesn't exist in the database.

If the data is already in the database, then an update will be performed. Developers commonly refer to this operation as an "upsert".

To update the database, run the "update-database" command in the Package Manager Console.

The -Verbose flag can be used to see the SQL statements that Code First Migrations is running to create our database.

A migration class's Down method contains code to remove the updates that were applied in the Up method, so that the database will be in sync with the previous version of the model. TRUE.

You can think of the Down method as being responsible for "downgrading" the database.

The Configuration class provides a method named "Seed" that you can use to seed your database with data.

The Seed method is passed an instance of the database context class, which can be used to reference any of the defined DbSet properties.

To regenerate a migration you can rerun the Add-Migration command and add the "-Force" flag.

Alternatively, you can just delete the migration code file and rerun the Add-Migration command without the -Force flag.

A migration class's Up method contains code to update the database to be in sync with the model that was used to generate the migration. TRUE.

You can think of the Up method as being responsible for "upgrading" the database.

----------------------------------------------------------------





















