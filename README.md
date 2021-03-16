# dotnet-ef-migrations

https://teamtreehouse.com/library/entity-framework-migrations

In this Treehouse course, I learned how to use Entity Framework Code First Migrations to propagate data model changes to a database.

1. Enabling Migrations
2. Adding Migrations
3. Updating the Database
4. Modifying Migrations
5. Deploying Migrations

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

The "-TargetMigration" flag can be used with the Update-Database command to update the database to a specific migration. Updating the database to a previous migration is useful when you're testing or debugging migrations.

Running the command Update-Database -TargetMigration $InitialDatabase will remove all of the applied migrations and restore the database to its original initial state. TRUE.

Restoring the database to its original initial state is useful when you need to test applying all of your migrations.

The Migration Fluent API provides a method named "Sql" that can be used to execute a SQL statement as part of the migration. The Sql method gives you a lot of power and flexibility when you need to customize a migration.


An option for applying pending migrations to databases hosted in shared environments, is to configure EF to use the "MigrateDatabaseTolatestVersion" database initializer.

While using the database initializer to migrate the database to the latest migration is easy to do and works well with automated workflows, it's not always possible to use.

While there are many development, testing, and deployment workflow variations, most contain some semblance of the dev, test, and prod environments. TRUE.

You can add a migration at any time, even when you have pending migrations that need to be applied to the database. FALSE. Attempting to add a migration when you have a pending migration will result in an error.

The "-Script" flag can be combined with the Update-Database command to generate a SQL script that can be used to apply the migration to the database.

Generating SQL scripts is helpful when you don't have direct access to test and production environment databases or the servers that they're hosted on.

When changing the cardinality of data in your model, Code First Migrations isn't able to generate the code that is necessary to transform existing data in your database into the new model. TRUE. You'll need to manually update the generated migration to workaround this limitation.

Running the command Update-Database -Script -SourceMigration $InitialDatabase will generate an idempotent SQL script that can be used to safely upgrade a database currently at any version to the latest version.

 An idempotent script can be safely executed against any version of the database, as it contains logic to determine which migrations have been applied and which haven't.

The MigrationHistory table's "MigrationId" column contains values that match the migration code filenames. This makes the rows in the MigrationHistory table easy to identify.
























































