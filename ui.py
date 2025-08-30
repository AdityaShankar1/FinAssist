def prepare_dashboard(df):
    if df.empty:
        return {"summary": "No data available.", "rows": []}

    # Simple analytics — sum & count
    total_balance = df["Balance"].sum()
    account_count = len(df)

    # Convert rows to dict for HTML table rendering
    rows = df.to_dict(orient="records")

    summary = f"Total Balance: ${total_balance:,.2f} across {account_count} accounts."
    return {"summary": summary, "rows": rows}
