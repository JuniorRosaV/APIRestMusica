using MusicaProjeto.API.Requests;
using MusicaProjeto.Modelos.Modelo;
using System.ComponentModel.DataAnnotations;

namespace ScreenSound.API.Requests;

public record MusicaRequest(
    string nome,
    int ArtistaId,
    int anoLancamento,
    ICollection<GenerosRequest> Generos = null
    );
public record MusicaRequestEdit(
    int Id,
    string nome,
    int ArtistaId,
    int anoLancamento,
    ICollection<GenerosRequest> generos = null
    );