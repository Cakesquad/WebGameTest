var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("webgame-postgres")
    .WithDataVolume("webgame-data")
    .WithPgWeb();

var db = postgres.AddDatabase("webgame");

var api = builder.AddProject<Projects.WebGame_Api>("webgame-api")
    .WaitFor(db)
    .WithReference(db);

builder.AddProject<Projects.WebGame_Web>("webgame-web")
    .WaitFor(api)
    .WithEnvironment("ConnectionStrings__Api", api.GetEndpoint("https"));

//builder.AddProject<Projects.WebGame>("webgame-maui")
//    .WithExplicitStart();

builder.Build().Run();
