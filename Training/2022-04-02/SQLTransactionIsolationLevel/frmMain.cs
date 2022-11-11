using System.Data;

namespace SQLTransactionIsolationLevel;

public partial class frmMain : Form
{
    private readonly IsolationManager _readUncommitted = new IsolationManager(IsolationLevel.ReadUncommitted);
    private readonly IsolationManager _readCommitted = new IsolationManager(IsolationLevel.ReadCommitted);
    private readonly IsolationManager _repeatableRead = new IsolationManager(IsolationLevel.RepeatableRead);
    private readonly IsolationManager _serializable = new IsolationManager(IsolationLevel.Serializable);

    public frmMain()
    {
        InitializeComponent();

        ucUncommitted.IsolationManager = _readUncommitted;
        ucUncommitted.OnSelection += UcUncommitted_OnSelection;

        ucRepeatable.IsolationManager = _repeatableRead;
        ucRepeatable.OnSelection += UcRepeatable_OnSelection;

        ucCommitted.IsolationManager = _readCommitted;
        ucCommitted.OnSelection += UcCommitted_OnSelection;

        ucSerializable.IsolationManager = _serializable;
        ucSerializable.OnSelection += UcSerializable_OnSelection;

    }

    private void UcSerializable_OnSelection(List<Models.Member> members)
    {
        ImportMembers(txtSerializable, members);
    }

    private void UcCommitted_OnSelection(List<Models.Member> members)
    {
        ImportMembers(txtCommitted, members);
    }

    private void UcRepeatable_OnSelection(List<Models.Member> members)
    {
        ImportMembers(txtRepeatable, members);
    }

    private void UcUncommitted_OnSelection(List<Models.Member> members)
    {
        ImportMembers(txtUncommited, members);
    }

    private void ImportMembers(RichTextBox textBox, List<Models.Member> members)
    {
        textBox.Text = string.Empty;

        foreach (var member in members)
        {
            textBox.Text += $"{member}{Environment.NewLine}";
        }
    }
}