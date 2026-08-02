using MediatR;
using WorldRank.Domain.Entities;

namespace WorldRank.Application.Queries.Players
{
    public record GetAllQuery : IRequest<List<Player>>
    {
    }
}