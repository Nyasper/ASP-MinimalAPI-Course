using System.ComponentModel.DataAnnotations;

namespace asp_course.DTOs;

public record class GameSummaryDTO 
  (
    int Id, 
    [Required][StringLength(50)] string Name, 
    [Required]string Genre, 
    [Range(1,100)] decimal Price,
    DateOnly ReleaseDate
  );

  public record class GameDetailDTO 
  (
    int Id, 
    [Required][StringLength(50)] string Name, 
    [Required]int GenreId, 
    [Range(1,100)] decimal Price,
    DateOnly ReleaseDate
  );


public record class CreateGameDTO
  (
    [Required][StringLength(50)] string Name, 
    int GenreId, 
    [Range(1,100)] decimal Price,
    DateOnly ReleaseDate
  );
  
  public record class UpdateGameDTO 
  (
    [Required][StringLength(50)] string Name, 
    [Required]int GenreId, 
    [Range(1,100)] decimal Price,
    DateOnly ReleaseDate
  );