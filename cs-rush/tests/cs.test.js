const csRush = require('../cs')

describe('CS Rush', () => {
  it('Deve realizar a distribuição e sobrecarregar o funcionário de ID 1', async () => {
    const csTotal = 4
    const customersTotal = 6
    const css = [[1, 60], [2, 20], [3, 95], [4, 75]]
    const customers = [[1, 90], [2, 20], [3, 70], [4, 40], [5, 60], [6, 10]]
    const vacantCss = [2, 4]

    const result = csRush(csTotal, customersTotal, css, customers, vacantCss)

    expect(result).toBe(1)
  })

  it('Deve realizar a distribuição equalizada e retornar 0', async () => {
    const csTotal = 4
    const customersTotal = 6
    const css = [[1, 60], [2, 20], [3, 95], [4, 75]]
    const customers = [[1, 90], [2, 20], [3, 70], [4, 40], [5, 60], [6, 10]]
    const vacantCss = []

    const result = csRush(csTotal, customersTotal, css, customers, vacantCss)

    expect(result).toBe(0)
  })
})
