
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// Design an API endpoint that receives user input and outputs a personalized greeting, such as "Hello, {user's name}." 
// when establishing parameters you can make them required by setting the variable without giving it an initial value, simply state the data type and variable name eg" string name"
// if we use an "="  then the parameter will have a default value; however, its only good practice to have default values if its a very good reason.
app.MapGet("/personalizedGreeting", (string name = "Master") => {
    
    // Array of strings with suggestions
    string[] suggestion = {
        "Go for a walk to be physically great!",
        "Try making your own sourdough bread for gut-health greatness!",
        "Take a nap!  You already work so hard! Get that mental & physical beauty greatness!",
        "Call up a family member who would love to hear your voice!  Relationship greatness here you come!",
        "Challenge yourself to learn something new every week to achieve greatness!",
        "Embrace failure as a stepping stone towards achieving greatness!",
        "Seek opportunities to step out of your comfort zone and embrace great growth!",
        "Celebrate your achievements, no matter how small, to stay motivated on your journey towards greatness!"};
    
    // Index randomized obtained from random method and choosing from the 0 index (inclusive) to suggestion.Length (exclusive) indexes
    int randomIndex = new Random().Next(0, suggestion.Length);
    string greeting = "Hello " + name + "!  I hope you've achieved greatness today!  If not, maybe try some of these suggestions:  \n" + suggestion[randomIndex];
    return greeting;
});


app.Run();