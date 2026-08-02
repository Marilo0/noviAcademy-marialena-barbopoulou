using MediatR;
using WorldRank.Domain.Entities;

namespace WorldRank.Application.Commands.Wallets
{
    public record DepositToWalletCommand(int Id, decimal Amount) : IRequest<Wallet?>;
}