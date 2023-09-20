public class Pagamento {
    public string FormaPagamento { get; private set; }
    public string Valor { get; private set; }

    public Pagamento(string FormaPagamento, string Valor) {
        this.FormaPagamento = FormaPagamento;
        this.Valor = Valor;
    }
}