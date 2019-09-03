const cssFactory = (css, vacantCss) => {
  const vacantLess = css.filter(cssItem => !vacantCss.includes(cssItem[0]));

  return vacantLess.map(item => ({
    id: item[0],
    xp: item[1],
    clientes: []
  }));
};

const customersFactory = customers =>
  customers.map(atual => ({
    id: atual[0],
    xp: atual[1],
    atendido: false
  }));

const csOver = cssAvailable =>
  cssAvailable.reduce((anterior, atual) =>
    anterior.clientes.length > atual.clientes.length ? anterior : atual
  );

const csEqual = (cssAvailable, over) => {
  let igual = false;

  cssAvailable.map(atual => {
    if (
      over.id !== atual.id &&
      over.clientes.length === atual.clientes.length
    ) {
      igual = true;
    }
  });

  return igual;
};

const distribution = (clients, cssAvailable, maxDistribution) => {
  clients.map(customer => {
    cssAvailable.map(func => {
      if (
        customer.xp <= func.xp &&
        customer.atendido === false &&
        func.clientes.length <= maxDistribution
      ) {
        func.clientes.push(customer);
        customer.atendido = true;
      }
    });
  });
};

const csRush = (n, m, css, customers, vacantCss) => {
  const clients = customersFactory(customers);
  const customersTotal = m;

  const cssAvailable = cssFactory(css, vacantCss);
  const cssTotal = cssAvailable.length;

  const maxDistribution = customersTotal / cssTotal;

  distribution(clients, cssAvailable, maxDistribution);

  const over = csOver(cssAvailable);
  const equal = csEqual(cssAvailable, over);

  return equal ? 0 : over.id;
};

module.exports = csRush;
