// Cambiar la cultura del programa a colombia para que el colocar valores en miles no se coloquen con la coma (,) sino con el punto (.)
using System.Globalization;
using System.Threading;
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-CO");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("es-CO");

string especieMascota = "perro";   // "perro", "gato", "conejo", "reptil"
int edadMascota = 7;               // edad en años
double peso = 28.5;                // peso en kilogramos
bool tieneVacunasAlDia = false;
bool esSocio = true;
string motivoConsulta = "cirugia"; // "vacuna", "revision", "cirugia", "urgencia"

// Parte 1 — Clasificación por etapa de vida
System.Console.WriteLine("=== Reporte de Atención Veterinaria ===");
string etapaVida = edadMascota switch
{
    >= 0 and < 1 => "Cachorro",
    >= 1 and <= 3 => "Joven",
    >= 4 and <= 8 => "Adulto",
    > 8 => "Senior",
    _ => "No valida"
};
System.Console.WriteLine($"Mascota: {especieMascota} | Edad: {edadMascota} años | Etapa: {etapaVida}");

// Parte 2 — Alerta de vacunación
string alertaVacuna;
if ((especieMascota == "perro" || especieMascota == "gato") && !tieneVacunasAlDia)
{
    alertaVacuna = "ALERTA: vacunación urgente requerida";
}
else if ((especieMascota == "perro" || especieMascota == "gato") && tieneVacunasAlDia)
{
    alertaVacuna = "Vacunación al día";
}
else
{
    alertaVacuna = "Esquema de vacunación no aplica";
}
System.Console.WriteLine($"Estado de vacunación: {alertaVacuna}");

// Parte 3 — Costo base de la consulta
decimal costoBase;
switch (motivoConsulta)
{
    case "vacuna":
        costoBase = 35000;
        break;
    case "revision":
        costoBase = 50000;
        break;
    case "cirugia":
        costoBase = 280000;
        break;
    case "urgencia":
        costoBase = 150000;
        break;
    default:
        costoBase = 0;
        break;
}
System.Console.WriteLine($"Motivo: cirugia | Costo base: {costoBase:C0}");

// Parte 4 — Descuento por membresía y peso
double porcentajeDescuento = (esSocio && peso > 25) ? 15.0 : esSocio ? 10.0 : 0.0;

decimal descuento = costoBase * (decimal)(porcentajeDescuento / 100);
decimal costoFinal = costoBase - descuento;

Console.WriteLine($"Descuento: {porcentajeDescuento}% | Costo final: {costoFinal:C0}");

// Parte 5 — Recomendación post-consulta
string recomendacion;
if (motivoConsulta == "cirugia")
{
    if (etapaVida == "Senior")
    {
        recomendacion = "Reposo absoluto por 10 días, control post-operatorio obligatorio";
    }
    else
    {
        recomendacion = "Reposo por 5 días, evitar ejercicio intenso";
    }
}
else if (motivoConsulta == "urgencia")
{
    if (tieneVacunasAlDia == false)
    {
        recomendacion = "Atender urgencia y programar vacunación inmediata";
    }
    else
    {
        recomendacion = "Seguimiento en 48 horas";
    }
}
else
{
    recomendacion = "Seguimiento en próxima consulta de rutina";
}
System.Console.WriteLine($"Recomendación: {recomendacion}");