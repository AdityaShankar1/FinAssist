from flask import Flask, render_template
from .db import get_financial_data

app = Flask(__name__)

@app.route('/')
def dashboard():
    df = get_financial_data()
    rows = df.to_dict(orient='records')   # converts to list of dicts
    summary = f"Loaded {len(rows)} records from investment survey."
    return render_template('index.html', dashboard={"summary": summary, "rows": rows})

if __name__ == '__main__':
    app.run(debug=True)