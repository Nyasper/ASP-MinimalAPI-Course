using asp_course.DTOs;
using asp_course.Entities;

namespace asp_course.Mapping;

public static class GenreMapping 
{
  public static GenreDto ToDto(this Genre gnre)
  {
    return new GenreDto(gnre.Id, gnre.Name);
  }
}
