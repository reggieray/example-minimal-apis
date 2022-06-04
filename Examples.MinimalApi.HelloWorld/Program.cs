var app = WebApplication.Create();

app.MapGet("hello-world", () => "Hello world!");

app.Run();