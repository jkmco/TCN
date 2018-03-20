using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCN.Controllers.Resources;
using TCN.Models;
using TCN.Persistence;

namespace TCN.Controllers
{
    [Route("/api/trades")]
    public class TradeController : Controller
    {
        private readonly IMapper mapper;
        private readonly ITradeRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public TradeController(IMapper mapper, ITradeRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> CreateTrade([FromBody] SaveTradeResource tradeResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var trade = mapper.Map<SaveTradeResource, Trade>(tradeResource);

            repository.Add(trade);
            await unitOfWork.CompleteAsync();

            var result = mapper.Map<Trade, SaveTradeResource>(trade);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateTrade(int id, [FromBody] SaveTradeResource tradeResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var trade = await repository.GetTradeAsync(id);

            if (trade == null)
                return NotFound();

            mapper.Map<SaveTradeResource, Trade>(tradeResource, trade);

            await unitOfWork.CompleteAsync();

            var result = mapper.Map<Trade, LoadTradeResource>(trade);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTrade(int id)
        {
            var trade = await repository.GetTradeAsync(id, includeRelated: false);

            if (trade == null)
                return NotFound();

            repository.Remove(trade);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrade(int id)
        {
            var trade = await repository.GetTradeAsync(id);

            if (trade == null)
                return NotFound();

            var result = mapper.Map<Trade, LoadTradeResource>(trade);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IEnumerable<LoadTradeResource>> GetTrades(TradeQueryResource filterResource)
        {
            var filter = mapper.Map<TradeQueryResource, TradeQuery>(filterResource);
            var trades = await repository.GetAllTradeAsync(filter);

            return mapper.Map<IEnumerable<Trade>, IEnumerable<LoadTradeResource>>(trades);
        }

        [HttpGet("coins")]
        public async Task<IActionResult> GetTradeCoins()
        {
            var coins = await repository.GetAllCoinAsync();

            if (coins == null)
                return NotFound();

            var result = mapper.Map<IEnumerable<TradeCoin>, IEnumerable<KeyValuePairResource>>(coins);

            return Ok(result);
        }

        [HttpGet("fxs")]
        public async Task<IActionResult> GetTradeFxs()
        {
            var fxs = await repository.GetAllFxAsync();

            if (fxs == null)
                return NotFound();

            var result = mapper.Map<IEnumerable<TradeFx>, IEnumerable<KeyValuePairResource>>(fxs);

            return Ok(result);
        }


    }
}