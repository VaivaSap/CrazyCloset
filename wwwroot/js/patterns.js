const itemCounts = {};
const itemImages = {};

logs.forEach(log => {
    const itemName = log.ItemName;
    itemCounts[itemName] = (itemCounts[itemName] || 0) + 1;
    if (!itemImages[itemName]) {
        itemImages[itemName] = log.FilePath;
    }
});

const labels = Object.keys(itemCounts);
const data = Object.values(itemCounts);

new Chart(document.getElementById('popularityChart'), {
    type: 'bar',
    data: {
        labels: labels,
        datasets: [{
            label: 'Times Worn',
            data: data,
            backgroundColor: 'rgb(255, 165, 0)'
        }]
    },
    options: {
        scales: {
            y: {
                ticks: {
                    stepSize: 1,
                    precision: 0
                }
            }
        },
        onHover: (event, activeElements) => {
            const tooltip = document.getElementById('chartTooltip');
            if (activeElements.length > 0) {
                const index = activeElements[0].index;
                const itemName = labels[index];
                const filepath = itemImages[itemName];

                document.getElementById('tooltipImage').src = '/items/' + filepath;
                document.getElementById('tooltipText').textContent = `${itemName}: ${data[index]} times`;

                tooltip.style.display = 'block';
                tooltip.style.left = event.native.pageX + 10 + 'px';
                tooltip.style.top = event.native.pageY + 10 + 'px';
            } else {
                tooltip.style.display = 'none';
            }
        }
    }
});