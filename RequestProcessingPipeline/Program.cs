using RequestProcessingPipeline;

var builder = WebApplication.CreateBuilder(args);

// ��� ������ �������� ������ ������� IDistributedCache, � 
// ASP.NET Core ������������� ���������� ���������� IDistributedCache
builder.Services.AddDistributedMemoryCache();// ��������� IDistributedMemoryCache
builder.Services.AddSession();  // ��������� ������� ������
var app = builder.Build();

app.UseSession();   // ��������� middleware-��������� ��� ������ � ��������

// ��������� middleware-���������� � �������� ��������� �������.
app.UseFrom20000to99999();
app.UseFrom10001to19999();
app.UseFrom1000to9999();
app.UseFrom101to999();
app.UseFromTwentyToHundred();
app.UseFromElevenToNineteen();
app.UseFromOneToTen();

app.Run();
