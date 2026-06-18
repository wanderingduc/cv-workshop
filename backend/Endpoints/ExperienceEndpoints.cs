using backend.Data.Mappers;
using backend.Services;

namespace backend.Endpoints;

public static class ExperienceEndpoints
{
    public static void MapExperienceEndpoints(this WebApplication app)
    {
        // GET /experiences
        app.MapGet(
                "/experiences",
                async (ICvService cvService) =>
                {
                    // TODO: Oppgave 2

                    var experiences = await cvService.GetAllExperiencesAsync();
                    // if (experiences == null)
                    // {
                    //     return Results.NotFound("No experiences found");
                    // }
                    var experienceDtos = experiences.Select(e => e.ToDto()).ToList();

                    return Results.Ok(experienceDtos);
                }
            )
            .WithName("GetAllExperiences")
            .WithTags("Experiences");

        // GET /experiences/{id}
        app.MapGet(
                "/experiences/{id:guid}",
                async (Guid id, ICvService cvService) =>
                {
                    // TODO: Oppgave 2
                    var exp = await cvService.GetExperienceByIdAsync(id);
                    if (exp == null)
                    {
                        return Results.NotFound("Experience does not exist");
                    }
                    var expDto = exp.ToDto();
                    return Results.Ok(expDto);
                }
            )
            .WithName("GetExperienceById")
            .WithTags("Experiences");

        // GET /experiences/type/{type}
        app.MapGet(
                "/experiences/type/{type}",
                async (string type, ICvService cvService) =>
                {
                    // TODO: Oppgave 3
                    var exps = await cvService.GetExperiencesByTypeAsync(type);
                    var expDtos = exps.Select(e => e.ToDto()).ToList();

                    return Results.Ok(expDtos);
                }
            )
            .WithName("GetExperiencesByType")
            .WithTags("Experiences");

        app.MapGet(
            "/experiences/user/{userid}",
             async (Guid userid, ICvService cvService) =>
             {
                 var exps = await cvService.GetExperiencesByUserIdAsync(userid);
                 var expDtos = exps.Select(e => e.ToDto()).ToList();
                 return Results.Ok(expDtos);
             }
        )
        .WithName("GetExperienceByUserIdAsync")
        .WithTags("Experiences");
    }
}
