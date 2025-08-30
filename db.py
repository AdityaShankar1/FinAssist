import mysql.connector
import pandas as pd

def get_financial_data():
    # MySQL connection settings
    connection = mysql.connector.connect(
        host="localhost",
        user="root",
        password="09012004Adi$",
        database="finassist"
    )
    cursor = connection.cursor()

    # Fetch only gender, age, main_avenue
    query = """
        SELECT gender, age, main_avenue 
        FROM investment_survey
        LIMIT 10;
    """
    cursor.execute(query)
    rows = cursor.fetchall()

    # Create DataFrame with correct column names
    df = pd.DataFrame(rows, columns=["Gender", "Age", "Main Avenue"])

    cursor.close()
    connection.close()
    return df