

using backend.Data.Models;
using backend.DTOs;

public static class ExperienceMapper {
    


    public static ExperienceDto ToDto(this Experience exp) =>
        new(
            Id: exp.Id,
            UserId: exp.UserId,
            Title: exp.Title,
            Role: exp.Role,
            Type: exp.Type,
            StartDate: exp.StartDate,
            EndDate: exp.EndDate,
            Description: exp.Description,
            ImageUrl: exp.ImageUrl,
            Company: exp.Company
        );
}