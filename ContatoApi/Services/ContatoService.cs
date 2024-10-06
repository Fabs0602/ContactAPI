using ContatoApi.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ContatoApi.Services
{
    public class ContatoService
    {
        private readonly IMongoCollection<Contato> _contatos;

        public ContatoService(IConnectionStringProvider connectionStringProvider)
        {
            var connectionString = connectionStringProvider.GetConnectionString("MongoDb");
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ContatoDb");
            _contatos = database.GetCollection<Contato>("Contatos");
        }

        public async Task<List<Contato>> GetAsync() => 
            await _contatos.Find(c => true).ToListAsync();

        public virtual async Task<Contato> GetAsync(string id) =>
            await _contatos.Find(c => c.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Contato contato) =>
            await _contatos.InsertOneAsync(contato);

        public async Task UpdateAsync(string id, Contato contato) =>
            await _contatos.ReplaceOneAsync(c => c.Id == id, contato);

        public async Task DeleteAsync(string id) =>
            await _contatos.DeleteOneAsync(c => c.Id == id);
    }
}