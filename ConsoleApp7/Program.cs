import pandas as pd
import numpy as np
import seaborn as sns

# load the dataset
iris = sns.load_dataset('iris')

# drop "species" column
iris = iris.drop("species", axis = 'columns')

# add two new columns
iris = iris.assign(sepal_sum = lambda x: x.sepal_length + x.sepal_width)
iris = iris.assign(petal_sum = lambda x: x.petal_length + x.petal_width)

# print the modified iris dataset
print(iris)

# extracting summary from iris dataset
data = { 'mean': [], 'std': [], 'min': [], 'max': []}
index = []
for col in iris.columns:
    index.append(col)
    data['mean'].append(round(iris[col].mean(), 6))
    data['std'].append(round(iris[col].std(), 6))
    data['min'].append(round(iris[col].min(), 6))
    data['max'].append(round(iris[col].max(), 6))

# rearrage the data as 'sepal_sum' comes at third place in given sample
index.insert(2, index[-2])
index.pop(-2)

for key in data:
    data[key].insert(2, data[key][-2])
    data[key].pop(-2)

new_df = pd.DataFrame(data, index)

# print the new data framea
print(new_df)