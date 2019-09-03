const operadoresInit = cssVacantLess => {
  return cssVacantLess.reduce((anterior, atual) => {
    const obj = {
      [atual[0]]: {
        id: atual[0],
        xp: atual[1],
        clientes: []
      }
    }
    return Object.assign(anterior, obj)
  }, {})
}

const customersInit = customers => {
  return customers.reduce((anterior, atual) => {
    const obj = {
      [atual[0]]: {
        id: atual[0],
        xp: atual[1],
        atendido: false
      }
    }
    return Object.assign(anterior, obj)
  }, {})
}

const arrayRemove = (arr, value) => {
  const results = arr.filter(function (elem) {
    return elem[0] != value
  })

  return results
}

function csRush (n, m, css, customers, vacant_css) {
  const cssVacantLess = css.filter(cssItem => {
    return !vacant_css.includes(cssItem[0]) && cssItem
  })

  let operadores = operadoresInit(cssVacantLess)
  let operadoresValues = Object.values(operadores)
  const clientes = customersInit(customers)

  const qtdOperadores = Object.keys(operadores).length
  const distribuicao = m / qtdOperadores

  Object.values(clientes).map(customer => {
    operadoresValues.map(func => {
      if (
        customer.xp <= func.xp &&
        customer.atendido === false &&
        func.clientes.length <= distribuicao
      ) {
        func.clientes.push(customer)
        customer.atendido = true
      }
    })
  })

  const maior = operadoresValues.reduce((anterior, atual) => {
    return anterior.clientes.length > atual.clientes.length ? anterior : atual
  })

  let igual = false

  operadoresValues.reduce((anterior, atual) => {
    if (
      maior.id != atual.id &&
      maior.clientes.length === atual.clientes.length
    ) {
      igual = true
    }
  })

  return igual ? 0 : maior.id
}

module.exports = csRush
