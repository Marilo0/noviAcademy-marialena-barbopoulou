using MediatR;
using WorldRank.Domain.Enums;
namespace WorldRank.Application.Commands.Wallets;

public record CreateWalletCommand(int PlayerId, Currency Currency) : IRequest<int>;