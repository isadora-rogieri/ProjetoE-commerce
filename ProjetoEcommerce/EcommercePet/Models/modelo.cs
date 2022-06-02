using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace EcommercePet.Models
{
    [DataContract]
    public abstract class BaseModel
    {
        [DataMember]
        public int Id { get; protected set; }
    }

    public class Produto : BaseModel
    {
        public Produto()
        {

        }

        [Required]
        public string Codigo { get; private set; }
        [Required]
        public string Nome { get; private set; }
        [Required]
        public string Descricao { get; private set; }
        [Required]
        public decimal Preco { get; private set; }

        public Produto(string codigo, string nome, string descricao, decimal preco)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Preco = preco;
        }
    }

    [DataContract]
    public class Cliente : BaseModel
    {
        public Cliente()
        {
        }

        public virtual Pedido Pedido { get; set; }
        [MinLength(5, ErrorMessage = "Tamanho mínimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = "Tamanho máximo 50 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; } = "";
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Email { get; set; } = "";
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Telefone { get; set; } = "";
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Endereco { get; set; } = "";
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Complemento { get; set; } = "";
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Bairro { get; set; } = "";
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Municipio { get; set; } = "";
        [Required(ErrorMessage = "Campo obrigatório")]
        public string UF { get; set; } = "";
        [Required(ErrorMessage = "Campo obrigatório")]
        public string CEP { get; set; } = "";

        internal void Update(Cliente novoCliente) {
            this.Nome = novoCliente.Nome;
            this.Telefone = novoCliente.Telefone;
            this.Email = novoCliente.Email;
            this.Endereco = novoCliente.Endereco;
            this.Complemento = novoCliente.Complemento;
            this.Bairro = novoCliente.Bairro;
            this.Municipio = novoCliente.Municipio;
            this.UF = novoCliente.UF;
            this.CEP = novoCliente.CEP;

        }
    }


    [DataContract]
    public class ItemPedido : BaseModel
    {
        [Required]
        [DataMember]
        public Pedido Pedido { get; private set; }
        [Required]
        [DataMember]
        public Produto Produto { get; private set; }
        [Required]
        [DataMember]
        public int Quantidade { get; private set; }
        [Required]
        [DataMember]
        public decimal PrecoUnitario { get; private set; }
        [DataMember]
        public decimal Subtotal => Quantidade * PrecoUnitario;

        public ItemPedido()
        {

        }

        public ItemPedido(Pedido pedido, Produto produto, int quantidade, decimal precoUnitario)
        {
            Pedido = pedido;
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        internal void AtualizaQuantidade(int quantidade)
        {
            Quantidade = quantidade;
        }
    }

    public class Pedido : BaseModel
    {
        public Pedido()
        {
            Cliente = new Cliente();
        }

        public Pedido(Cliente cadastro)
        {
            Cliente = cadastro;
        }

        public List<ItemPedido> Itens { get; private set; } = new List<ItemPedido>();

        [Required]
        public virtual Cliente Cliente { get; private set; }


    }
}
